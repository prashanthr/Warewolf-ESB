﻿using System;
using System.Text;
using ActivityUnitTests;
using Dev2.DataList.Contract;
using System.Collections.Generic;

namespace Dev2.Activities.Specs.BaseTypes
{
    public abstract class RecordSetBases : BaseActivityUnitTest
    {
        protected RecordSetBases(dynamic variableList)
        {
            _variableList = variableList;
        }

        protected readonly dynamic _variableList;

        protected const string ResultVariable = "[[result]]";
        protected IDSFDataObject _result;
        protected string _recordset;
        protected string _recordSetName = "";
        protected string _fieldName = "";
        private readonly List<string> _addedRecordsets = new List<string>();
        

        protected void BuildShapeAndTestData(Tuple<string, string> variable)
        {
            _variableList.Add(variable);
            BuildShapeAndTestData();
        }
        protected void BuildShapeAndTestData(Tuple<string, string, string> variable)
        {
            _variableList.Add(variable);
            BuildShapeAndTestData();
        }
        protected void BuildShapeAndTestData(Tuple<string, string, string, string> variable)
        {
            _variableList.Add(variable);
            BuildShapeAndTestData();
        }

        protected void BuildShapeAndTestData()
        {
            var shape = new StringBuilder();
            shape.Append("<root>");

            var data = new StringBuilder();
            data.Append("<root>");

            int row = 1;
            foreach (var variable in _variableList)
            {
                Build(variable, shape, data);
                row++;
            }
            shape.Append("</root>");
            data.Append("</root>");

            CurrentDl = shape.ToString();
            TestData = data.ToString();
        }

        private void Build(dynamic variable, StringBuilder shape, StringBuilder data)
        {
            string variableName = DataListUtil.RemoveLanguageBrackets(variable.Item1);
            if (variableName.Contains("(") && variableName.Contains(")"))
            {
                var startIndex = variableName.IndexOf("(");
                var endIndex = variableName.IndexOf(")");

                int i = (endIndex - startIndex) - 1;

                if (i > 0)
                {
                    variableName = variableName.Remove(startIndex + 1, i);
                }

                variableName = variableName.Replace("(", "").Replace(")", "").Replace("*", "");
                var variableNameSplit = variableName.Split(".".ToCharArray());

                if (!_addedRecordsets.Contains(variableNameSplit[0]))
                {
                    shape.Append(string.Format("<{0}>", variableNameSplit[0]));
                    shape.Append(string.Format("<{0}/>", variableNameSplit[1]));
                    shape.Append(string.Format("</{0}>", variableNameSplit[0]));
                    _addedRecordsets.Add(variableNameSplit[0]);
                }

                data.Append(string.Format("<{0}>", variableNameSplit[0]));
                data.Append(string.Format("<{0}>{1}</{0}>", variableNameSplit[1], variable.Item2));
                data.Append(string.Format("</{0}>", variableNameSplit[0]));

                _recordSetName = variableNameSplit[0];
                _fieldName = variableNameSplit[1];
            }
            else
            {
                shape.Append(string.Format("<{0}/>", variableName));
                data.Append(string.Format("<{0}>{1}</{0}>", variableName, variable.Item2));
            }
        }

        protected string RetrieveItemForEvaluation(enIntellisensePartType partType, string value)
        {
            string rawRef = DataListUtil.StripBracketsFromValue(value);
            string objRef = string.Empty;

            if (partType == enIntellisensePartType.RecorsetsOnly)
            {
                objRef = DataListUtil.ExtractRecordsetNameFromValue(rawRef);
            }
            else if (partType == enIntellisensePartType.RecordsetFields)
            {
                objRef = DataListUtil.ExtractFieldNameFromValue(rawRef);
            }

            return objRef;
        }
    }
}