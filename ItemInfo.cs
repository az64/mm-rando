using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Linq;
using System.Text;
using System.Runtime.Serialization.Json;
using System.IO;
using System.CodeDom;
using System.Collections.ObjectModel;
using System.Reflection;

namespace MMRando
{
    [DataContract]
    public class ItemInfo
    {
        [DataMember(Order = 1)]
        public int MMRIndex;

        [DataMember(Order = 2)]
        public string Name;

        [DataMember(Order = 3)]
        public bool Repeatable = false;

        [DataMember(Order = 4)]
        public bool CycleRepeatable = false;

        [DataMember(Order = 5)]
        public int GetItemIndex = -1;

        [DataMember(Order = 6)]
        public List<int> BottleIndexes = new List<int>();

        [DataMember(Order = 7)]
        public List<WriteByte> GiveItemAddresses = new List<WriteByte>();

        [DataMember(Order = 8)]
        public List<string> LocationHints = new List<string>();

        [DataMember(Order = 9)]
        public List<string> ItemHints = new List<string>();

        [DataMember(Order = 0xA)]
        public bool IsUsefulItem = true;


        private static DataContractJsonSerializer GetSerializer()
        {
            ItemInfoTypeSurrogate surrogate = new ItemInfoTypeSurrogate();
            DataContractJsonSerializer serializer
                = new DataContractJsonSerializer(typeof(List<ItemInfo>),
                new List<Type>(), int.MaxValue, false, surrogate, false);
            return serializer;
        }
        public static void Serialize(List<ItemInfo> itemInfo, string path)
        {
            var serializer = GetSerializer();

            using (var stream = File.Open(path, FileMode.Create))
            {
                using (var writer = JsonReaderWriterFactory.CreateJsonWriter(stream, Encoding.UTF8))
                {
                    serializer.WriteObject(writer, itemInfo);
                }
            }
        }

        public static List<ItemInfo> Deserialize(string path)
        {
            var serializer = GetSerializer();
            List<ItemInfo> result;
            using (var stream = File.OpenRead(path))
            {
                result = (List<ItemInfo>)serializer.ReadObject(stream);
            }
            return result.OrderBy(x => x.MMRIndex).ToList();
        }
    }

    public class WriteByte
    {
        public int Address;

        public int Value;

        public static implicit operator WriteByte(WriteByteSurrogated wb)
        {
            return new WriteByte()
            {
                Address = int.Parse(wb.Address, System.Globalization.NumberStyles.HexNumber),
                Value = int.Parse(wb.Value, System.Globalization.NumberStyles.HexNumber)
            };
        }
    }

    [DataContract]
    public class WriteByteSurrogated
    {
        [DataMember]
        public string Address;

        [DataMember]
        public string Value;

        public static implicit operator WriteByteSurrogated(WriteByte value)
        {
            return new WriteByteSurrogated()
            {
                Address = value.Address.ToString("X"),
                Value = value.Value.ToString("X2")
            };
        }
    }

    public class ItemInfoTypeSurrogate : IDataContractSurrogate
    {

        public Type GetDataContractType(Type type)
        {
            if (typeof(WriteByte).IsAssignableFrom(type))
            {
                return typeof(WriteByteSurrogated);
            }
            return type;
        }

        public object GetDeserializedObject(object obj, Type targetType)
        {
            if (obj is WriteByteSurrogated value)
            {
                return (WriteByte)value;
            }
            return obj;
        }

        public object GetObjectToSerialize(object obj, Type targetType)
        {
            if (obj is WriteByte value)
            {
                return (WriteByteSurrogated)value;
            }
            return obj;
        }

        public Type GetReferencedTypeOnImport(string typeName, string typeNamespace, object customData)
        {
            if (typeName.Equals(nameof(WriteByteSurrogated)))
            {
                return typeof(WriteByte);
            }
            return null;
        }

        public CodeTypeDeclaration ProcessImportedType(CodeTypeDeclaration typeDeclaration, CodeCompileUnit compileUnit)
        {
            return typeDeclaration;
        }

        public object GetCustomDataToExport(MemberInfo memberInfo, Type dataContractType)
        {
            return null;
        }

        public object GetCustomDataToExport(Type clrType, Type dataContractType)
        {
            return null;
        }

        public void GetKnownCustomDataTypes(Collection<Type> customDataTypes)
        {
        }
    }
}
