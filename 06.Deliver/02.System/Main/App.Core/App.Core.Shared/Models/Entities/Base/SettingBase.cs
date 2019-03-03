namespace App.Core.Shared.Models.Entities
{
    public abstract class SettingBase : UntenantedAuditedRecordStatedTimestampedGuidIdEntityBase, IHasKey, IHasEnabled,
        IHasSerializedTypeValue
    {
        public bool Enabled { get; set; }
        public string Key { get; set; }

        public string SerializedTypeName { get; set; }
        public string SerializedTypeValue { get; set; }


        public void SetValue<T>(T value)
        {
            this.SerializedTypeName = typeof(T).ToString();
            this._value = value;
        }
        private object _value;

        public T GetValue<T>()
        {
            // Has been set, so SerializedTypeName is correct,
            // can get out early:
            if (this._value != null)
            {
                return (T) this._value;
            }
            // otherwise deserialize:
            //_value = <default>T;

            this.SerializedTypeName = typeof(T).ToString();

// Then get out as best as one can:
            return (T) this._value;
        }
    }
}