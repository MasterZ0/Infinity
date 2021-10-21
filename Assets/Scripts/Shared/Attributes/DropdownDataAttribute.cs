using System;

namespace Infinity.Shared {

    /// <summary>
    /// DropdownData is used on any property and creates a dropdown with configurable options.
    /// Use this to give the user a specific set of options to select from.
    /// </summary>
    [AttributeUsage(AttributeTargets.Field)]
    public class DropdownDataAttribute : Attribute {

        /// <summary>
        /// List of objects
        /// </summary>
        public string Collection;

        /// <summary>
        /// Reload the datas
        /// </summary>
        public bool ShowRefreshButton;

        /// <summary>
        /// Order the dropdown list
        /// </summary>
        public bool OrderByName;
        public DropdownDataAttribute(string collection) {
            Collection = collection;
        }
    }
}
