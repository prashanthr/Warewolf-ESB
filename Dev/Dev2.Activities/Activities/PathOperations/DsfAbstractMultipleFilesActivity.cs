﻿
using Dev2.DataList.Contract;
using Dev2.DataList.Contract.Binary_Objects;
using Dev2.DataList.Contract.Value_Objects;
using Dev2.PathOperations;
using Dev2.Util;
using System;
using System.Activities;
using System.Collections.Generic;
using Unlimited.Applications.BusinessDesignStudio.Activities;
using Unlimited.Applications.BusinessDesignStudio.Activities.Utilities;

namespace Dev2.Activities.PathOperations
{
    /// <summary>
    /// PBI : 1172
    /// Status : New
    /// Purpose : To provide an activity that can move a file/folder via FTP, FTPS and file system
    /// </summary>
    public abstract class DsfAbstractMultipleFilesActivity : DsfAbstractFileActivity
    {
        protected DsfAbstractMultipleFilesActivity(string displayName)
            : base(displayName)
        {
            InputPath = string.Empty;
            OutputPath = string.Empty;
            DestinationPassword = string.Empty;
            DestinationUsername = string.Empty;
        }

        protected override IList<OutputTO> ExecuteConcreteAction(NativeActivityContext context,
                                                                 out ErrorResultTO allErrors)
        {
            IList<OutputTO> outputs = new List<OutputTO>();
            IDSFDataObject dataObject = context.GetExtension<IDSFDataObject>();
            IDataListCompiler compiler = DataListFactory.CreateDataListCompiler();

            allErrors = new ErrorResultTO();
            ErrorResultTO errors;
            Guid executionId = dataObject.DataListID;
            IDev2IteratorCollection colItr = Dev2ValueObjectFactory.CreateIteratorCollection();

            //get all the possible paths for all the string variables
            IBinaryDataListEntry inputPathEntry = compiler.Evaluate(executionId, enActionType.User, InputPath, false,
                                                                    out errors);
            allErrors.MergeErrors(errors);
            IDev2DataListEvaluateIterator inputItr = Dev2ValueObjectFactory.CreateEvaluateIterator(inputPathEntry);
            colItr.AddIterator(inputItr);

            IBinaryDataListEntry outputPathEntry = compiler.Evaluate(executionId, enActionType.User, OutputPath, false,
                                                                     out errors);
            allErrors.MergeErrors(errors);
            IDev2DataListEvaluateIterator outputItr = Dev2ValueObjectFactory.CreateEvaluateIterator(outputPathEntry);
            colItr.AddIterator(outputItr);

            IBinaryDataListEntry usernameEntry = compiler.Evaluate(executionId, enActionType.User, Username, false,
                                                                   out errors);
            allErrors.MergeErrors(errors);
            IDev2DataListEvaluateIterator unameItr = Dev2ValueObjectFactory.CreateEvaluateIterator(usernameEntry);
            colItr.AddIterator(unameItr);

            IBinaryDataListEntry passwordEntry = compiler.Evaluate(executionId, enActionType.User, Password, false,
                                                                   out errors);
            allErrors.MergeErrors(errors);
            IDev2DataListEvaluateIterator passItr = Dev2ValueObjectFactory.CreateEvaluateIterator(passwordEntry);
            colItr.AddIterator(passItr);

            IBinaryDataListEntry DestinationUsernameEntry = compiler.Evaluate(executionId, enActionType.User, DestinationUsername, false,
                                                                  out errors);
            allErrors.MergeErrors(errors);
            IDev2DataListEvaluateIterator desunameItr = Dev2ValueObjectFactory.CreateEvaluateIterator(DestinationUsernameEntry);
            colItr.AddIterator(desunameItr);

            IBinaryDataListEntry destinationPasswordEntry = compiler.Evaluate(executionId, enActionType.User, DestinationPassword, false,
                                                                   out errors);
            allErrors.MergeErrors(errors);
            IDev2DataListEvaluateIterator despassItr = Dev2ValueObjectFactory.CreateEvaluateIterator(destinationPasswordEntry);
            colItr.AddIterator(despassItr);

            outputs.Add(DataListFactory.CreateOutputTO(Result));

            if (dataObject.IsDebug || dataObject.RemoteInvoke)
            {
                AddDebugInputItem(InputPath, "Input Path", inputPathEntry, executionId);
                AddDebugInputItemUserNamePassword(executionId, usernameEntry);
                AddDebugInputItem(OutputPath, "Output Path", outputPathEntry, executionId);
                AddDebugInputItemDestinationUsernamePassword(executionId, DestinationUsernameEntry, DestinationPassword, DestinationUsername);
                AddDebugInputItemOverwrite(executionId, Overwrite);
            }

            while (colItr.HasMoreData())
            {
                IActivityOperationsBroker broker = GetOperationBroker();

                Dev2CRUDOperationTO opTO = new Dev2CRUDOperationTO(Overwrite);

                try
                {
                    IActivityIOPath src = ActivityIOFactory.CreatePathFromString(colItr.FetchNextRow(inputItr).TheValue,
                                                                                 colItr.FetchNextRow(unameItr).TheValue,
                                                                                 colItr.FetchNextRow(passItr).TheValue,
                                                                                 true);

                    IActivityIOPath dst = ActivityIOFactory.CreatePathFromString(colItr.FetchNextRow(outputItr).TheValue,
                                                                                     colItr.FetchNextRow(desunameItr).TheValue,
                                                                                     colItr.FetchNextRow(despassItr).TheValue,
                                                                                     true);

                    IActivityIOOperationsEndPoint scrEndPoint = ActivityIOFactory.CreateOperationEndPointFromIOPath(src);
                    IActivityIOOperationsEndPoint dstEndPoint = ActivityIOFactory.CreateOperationEndPointFromIOPath(dst);
                    var result = ExecuteBroker(broker, scrEndPoint, dstEndPoint, opTO);
                    outputs[0].OutputStrings.Add(result);
                }
                catch (Exception e)
                {
                    outputs[0].OutputStrings.Add("Failure");
                    allErrors.AddError(e.Message);
                }
            }

            return outputs;

        }

        protected abstract string ExecuteBroker(IActivityOperationsBroker broker, IActivityIOOperationsEndPoint scrEndPoint, IActivityIOOperationsEndPoint dstEndPoint, Dev2CRUDOperationTO opTO);

        public Func<IActivityOperationsBroker> GetOperationBroker = () => ActivityIOFactory.CreateOperationsBroker();

        #region Properties

        /// <summary>
        /// Gets or sets a value indicating whether this is overwrite.
        /// </summary>
        [Inputs("Overwrite")]
        public bool Overwrite { get; set; }

        /// <summary>
        /// Gets or sets the input path.
        /// </summary>
        [Inputs("Input Path")]
        [FindMissing]
        public string InputPath { get; set; }

        /// <summary>
        /// Gets or sets the output path.
        /// </summary>
        [Inputs("Output Path")]
        [FindMissing]
        public string OutputPath { get; set; }

        /// <summary>
        /// Gets or sets the destination file/folder user name
        /// </summary>
        [Inputs("Destination Username"), FindMissing]
        public string DestinationUsername { get; set; }

        /// <summary>
        /// Gets or sets the destination file/folder password
        /// </summary>
        [Inputs("Destination Password"), FindMissing]
        public string DestinationPassword { get; set; }

        #endregion Properties

        public override void UpdateForEachInputs(IList<Tuple<string, string>> updates, NativeActivityContext context)
        {
            if (updates != null)
            {
                foreach (Tuple<string, string> t in updates)
                {

                    if (t.Item1 == InputPath)
                    {
                        InputPath = t.Item2;
                    }

                    if (t.Item1 == OutputPath)
                    {
                        OutputPath = t.Item2;
                    }
                }
            }
        }

        public override void UpdateForEachOutputs(IList<Tuple<string, string>> updates, NativeActivityContext context)
        {
            if (updates != null && updates.Count == 1)
            {
                Result = updates[0].Item2;
            }
        }


        #region GetForEachInputs/Outputs

        public override IList<DsfForEachItem> GetForEachInputs()
        {
            return GetForEachItems(InputPath, OutputPath);
        }

        public override IList<DsfForEachItem> GetForEachOutputs()
        {
            return GetForEachItems(Result);
        }

        #endregion
    }
}