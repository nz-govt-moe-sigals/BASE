namespace App.Core.Shared.Models.Entities
{
    public abstract class SettingBase : UntenantedTimestampedAuditedRecordStatedGuidIdEntityBase, IHasKey, IHasEnabled,
        IHasSerializedTypeValue
    {
        private object _value;
        public bool Enabled { get; set; }

        public string Key { get; set; }

        public string SerializedTypeName { get; set; }
        public string SerializedTypeValue { get; set; }


        public void SetValue<T>()
        {
            this.SerializedTypeName = typeof(T).ToString();
        }

        public T GetValue<T>()
        {
            if (this._value != null)
            {
                return (T) this._value;
            }
            this.SerializedTypeName = typeof(T).ToString();

            return (T) this._value;
        }
    }
}