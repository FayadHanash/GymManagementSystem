using System;
using GymManagementSystemDAL;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;

namespace GymManagementSystemBLL
{
    /// <summary>
    /// Class that manages the Groups.
    /// </summary>
    public class GroupManager : ListManager<Group>
    {
        #region Fields
        /// <summary>
        /// boolean that indicates whether if a group is loaded from database
        /// </summary>
        bool isGroupLoadedFromDB = true;

        #endregion Fields

        #region Constructor
        /// <summary>
        /// Default constructor
        /// </summary>
        public GroupManager() 
        {
            isGroupLoadedFromDB = true;
        }

        #endregion Constructor

        #region Properties
        /// <summary>
        /// Property related to isGroupLoadedFromDB field
        /// Both read and write access
        /// </summary>
        public bool IsGroupLoadedFromDB { get => isGroupLoadedFromDB; set => isGroupLoadedFromDB = value; }
        #endregion Properties

        #region Methods
        /// <summary>
        /// Add an object to the collection
        /// </summary>
        /// <param name="group">A type</param>
        /// <returns>True if successful, false otherwise.</returns>
        public bool Add(Group group)
        {
            if (isGroupLoadedFromDB)
            {
                return base.Add(group);
            }
            else
            {
                if (group != null)
                {
                    List.Add(group);
                    return true;
                }
                return false;
            }
        }

        /// <summary>
        /// Change the value of object at a given position in the collection
        /// </summary>
        /// <param name="type"> the object to replace an existing at index-position </param>
        /// <param name="index">The postion in the object collection in which the changes is to be done</param>
        /// <returns>True if successful, false otherwise</returns>
        public bool Update(Group group, int index)
        {
            if (isGroupLoadedFromDB)
            {
                return base.Update(group);
            }
            else
            {
                if (CheckIndex(index))
                {
                    List[index] = group;
                    return true;
                }
                return false;
            }
        }

        /// <summary>
        /// Remove an object from the collection at a given position 
        /// </summary>
        /// <param name="group"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        public bool Delete(Group group, int index)
        {
            if (isGroupLoadedFromDB)
            {
                return base.Delete(group,group.Id);
            }
            else
            {
                if (CheckIndex(index))
                {
                    List.RemoveAt(index);
                    return true;
                }
                return false;
            }
        }

        /// <summary>
        /// Method that updates the list
        /// </summary>
        public void UpdateList() => base.UpdateList();
        /// <summary>
        /// Method that saves data to a text file
        /// </summary>
        /// <param name="fileName">file name</param>
        public void SaveToFile(string fileName)
        {
            TextUtility<Group>.SaveToFile(fileName, this.List);
        }
        /// <summary>
        /// Method that loads data from a text file
        /// </summary>
        /// <param name="fileName">file name</param>
        public void LoadFromFile(string fileName)
        {
            List<Group> tempList = null;
            TextUtility<Group>.LoadFromFile(fileName, ref tempList);
            List = new List<Group>();
            List = tempList;
            isGroupLoadedFromDB = false;
        }

        /// <summary>
        /// Method that saves data to a binary file
        /// </summary>
        /// <param name="fileName">file name</param>
        public void BinarySerialize(string fileName)
        {
            BinSerializerUtility.Serialize(fileName, List);
        }

        /// <summary>
        /// Method that loads data from a binary file
        /// </summary>
        /// <param name="fileName">file name</param>
        public void BinaryDeserialize(string fileName)
        {
            List<Group> tempList = null;
            BinSerializerUtility.Deserialize(fileName, ref tempList);
            List = new List<Group>();
            List = tempList;
            isGroupLoadedFromDB = false;
        }



        /// <summary>
        /// Method that saves data to a xml file
        /// </summary>
        /// <param name="fileName">file name</param>
        public void XMLSerialize(string fileName)
        {
            XMLSerializerUtility.XMLSerialize(fileName, List);
        }

        /// <summary>
        /// Method that saves data from a xml file
        /// </summary>
        /// <param name="fileName">file name</param>
        public void XMLDeserialize(string fileName)
        {
            List<Group> tempList = null;
            XMLSerializerUtility.XMLDeserialize(fileName, ref tempList);
            List = new List<Group>();
            List= tempList;
            isGroupLoadedFromDB = false;
        }
        #endregion Methods
    }
}
