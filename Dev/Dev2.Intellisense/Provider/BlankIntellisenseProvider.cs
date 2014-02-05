﻿using System.Collections.Generic;
using Dev2.Studio.Core.Interfaces;

namespace Dev2.Intellisense.Provider
{
    public class BlankIntellisenseProvider : IIntellisenseProvider
    {
        #region Properties

        public bool HandlesResultInsertion { get; set; }

        public bool Optional { get; set; }

        #endregion Properties

        #region Methods

        public string PerformResultInsertion(string input, IntellisenseProviderContext context)
        {
            return string.Empty;
        }

        public IList<IntellisenseProviderResult> GetIntellisenseResults(IntellisenseProviderContext context)
        {
            return new List<IntellisenseProviderResult>();
        }

        public void Dispose()
        {
        }

        #endregion Methods
    }
}