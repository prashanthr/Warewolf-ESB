﻿using System;
using System.Collections.Generic;
using System.ComponentModel.Composition.Primitives;
using Caliburn.Micro;
using Dev2.Composition;
using Dev2.Studio.Core;
using Dev2.Studio.Core.AppResources.Enums;
using Dev2.Studio.Core.Interfaces;
using Dev2.Studio.Core.Messages;
using Dev2.Studio.Core.Workspaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Newtonsoft.Json.Linq;

namespace Dev2.Core.Tests.Webs
{
    [TestClass]
    public class WebServiceCallbackHandlerTests
    {
        static ImportServiceContext _importContext;

        private static Mock<IEventAggregator> _eventAgrregator;

        #region Class/TestInitialize

        [ClassInitialize]
        public static void ClassInitialize(TestContext testContext)
        {
            _importContext = new ImportServiceContext();
            ImportService.CurrentContext = _importContext;

            ImportService.Initialize(new List<ComposablePartCatalog>
            {
                new FullTestAggregateCatalog()
            });
            ImportService.AddExportedValueToContainer<IFrameworkSecurityContext>(new MockSecurityProvider(""));
            _eventAgrregator = new Mock<IEventAggregator>();
            var workspace = new Mock<IWorkspaceItemRepository>();
            ImportService.AddExportedValueToContainer(workspace.Object);

        }

        [TestInitialize]
        public void TestInitialize()
        {
            ImportService.CurrentContext = _importContext;
        }

        #endregion

        #region Save

        [TestMethod]
        public void WebServiceCallbackHandlerSaveWithValidArgsExpectedPublishesUpdateResourceMessage()
        {
            Guid ResourceID = Guid.NewGuid();

            var resourceModel = new Mock<IResourceModel>();
            resourceModel.Setup(r => r.ID).Returns(ResourceID);
            resourceModel.Setup(r => r.ResourceName).Returns("Some Name I Made Up For Testing");

            var resourceRepo = new Mock<IResourceRepository>();
            resourceRepo.Setup(r => r.ReloadResource(It.IsAny<Guid>(), It.IsAny<ResourceType>(), It.IsAny<IEqualityComparer<IResourceModel>>()))
                        .Returns(new List<IResourceModel> { resourceModel.Object });

            var envModel = new Mock<IEnvironmentModel>();
            envModel.Setup(e => e.ResourceRepository).Returns(resourceRepo.Object);

            var aggregator = new Mock<IEventAggregator>();
            var envRepo = new Mock<IEnvironmentRepository>();
            var handler = new WebServiceCallbackHandlerMock(aggregator.Object, envRepo.Object);

            aggregator.Setup(e => e.Publish(It.IsAny<UpdateResourceMessage>()))
                            .Callback<Object>(m =>
                            {
                                var msg = (UpdateResourceMessage)m;
                                Assert.AreEqual(ResourceID, msg.ResourceModel.ID);
                            })
                             .Verifiable();

            var jsonObj = JObject.Parse("{ 'ResourceID': '" + ResourceID + "'}");
            handler.TestSave(envModel.Object, jsonObj);

            aggregator.Verify(e => e.Publish(It.IsAny<UpdateResourceMessage>()), Times.Once());
        }

        #endregion



    }
}
