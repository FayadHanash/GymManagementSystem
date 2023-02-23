using System;

namespace GymManagementSystemBLL
{
    public class ListManager<T>
    {
        /// <summary>
        /// instance list
        /// </summary>
        private List<T> list;

        /// <summary>
        /// instance of the common class
        /// </summary>
        private Common<T> common;
        /// <summary>
        /// property for list
        /// just a getter access
        /// </summary>
        public List<T> List { get => list; set => list = value; }
        /// <summary>
        /// defualt constructor
        /// creates a new a instance
        /// </summary>
        public ListManager()
        {
            list = new List<T>();
            common = new Common<T>();
            UpdateList();
        }
        /// <summary>
        /// Return number of items in the list
        /// </summary>
        public int Count { get {  return list.Count; } }
        /// <summary>
        /// Add an object to the collection
        /// </summary>
        /// <param name="item">A type</param>
        /// <returns>True if successful, false otherwise.</returns>
        public bool Add(T item)
        {
            bool ok = common.Add(item);
            UpdateList();
            return ok;
        }
        /// <summary>
        /// Change the value of object in the collection
        /// </summary>
        /// <param name="item"> the object to replace an existing at index-position </param>
        /// <returns>True if successful, false otherwise</returns>
        public bool Update(T item)
        {
            bool ok = common.Update(item);
            UpdateList();
            return ok;
        }
        /// <summary>
        /// Check if the index is not out of collections's range
        /// </summary>
        /// <param name="index">Input index of the postion to be checked</param>
        /// <returns>True if successful, false otherwise</returns>
        public bool CheckIndex(int index) => index >= 0 && index < list.Count;
        /// <summary>
        /// Delete the collection
        /// </summary>
        //public void DeleteAll() => list = new List<T>();
        /// <summary>
        /// Remove an object from the collection at a given position 
        /// </summary>
        /// <param name="index">Index to object that is to be removed</param>
        /// <param name="t">type of t</param>
        /// <returns>True if successful, false otherwise.</returns>
        public bool Delete(T t, int index)
        {
            bool ok = common.Delete(t, index);
            UpdateList();
            return ok;
        }

        /// <summary>
        /// Return the right object from the collection at a given position
        /// </summary>
        /// <param name="index">input index of the position in the collection</param>
        /// <returns>True if successful, false otherwise</returns>
        public T GetAt(int index)
        {
            T t = default;
            if (CheckIndex(index))
            {
                t = list[index];
            }
            return t;
        }

        /// <summary>
        /// Sorting Method 
        /// </summary>
        /// <param name="sorter"></param>
        public void Sort(IComparer<T> sorter) { list.Sort(sorter); }

        /// <summary>
        /// Update the list
        /// </summary>
        protected void UpdateList()
        {
            list = new List<T>();

            common.DBList(new List<T>()).ForEach(x => list.Add(x));
        }
    }
}
