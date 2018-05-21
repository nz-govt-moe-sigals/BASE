namespace App.Core.Shared.Models.Entities
{
    using System;

    /// <summary>
    ///     A file persisted
    /// </summary>
    /// <internal>
    ///     Intentionally an Anemic Entity for easier serialization.
    ///     <para>
    ///         Behavior provided by Extension Methods.
    ///     </para>
    /// </internal>
    public class PersistedMedia : TenantFKAuditedRecordStatedTimestampedGuidIdEntityBase,
        IHasName,
        IHasValue<byte[]>,
        IHasTag,
        IHasDescription

    {
        private string _name;
        private int _size;

        ///// <summary>
        ///// Froms the file.
        ///// </summary>
        ///// <param name="fileName">Name of the file.</param>
        ///// <param name="ioService">The <see cref="IIOService"/> to use (can be from FileSystem in full desktop or 
        ///// IsolatedStorage based system.
        ///// </param>
        ///// <para>
        ///// If <paramref name="ioService"/> is left blank, will use 
        ///// <see cref="XAct.DependencyResolver"/> to retrieve an implementation
        ///// of <see cref="IFSIOService"/>
        ///// </para>
        ///// <returns></returns>
        //public static PersistedFile FromFile(string fileName, IIOService ioService=null)
        //{
        //    if (ioService == null)
        //    {
        //        ioService = XAct.DependencyResolver.Current.GetInstance<IFSIOService>();
        //    }

        //    PersistedFile messageAttachment = new PersistedFile();
        //    messageAttachment.LoadFromFile(fileName,ioService);
        //    return messageAttachment;
        //}

        ///// <summary>
        ///// Froms the stream.
        ///// </summary>
        ///// <param name="stream">The stream.</param>
        ///// <returns></returns>
        //public static PersistedFile FromStream(Stream stream)
        //{
        //    PersistedFile messageAttachment = new PersistedFile();
        //    messageAttachment.LoadFromStream(stream);
        //    return messageAttachment;
        //}


        /// <summary>
        ///     Gets the size of the attachment (<see cref="Value" /> Length).
        ///     <para>
        ///         Value is a calculated field, and is not serialized.
        ///     </para>
        /// </summary>
        /// <value>The size.</value>
        //[NonSerialized]
        public virtual int Size
        {
            get
            {
                this._size = this.Value?.Length ?? 0;
                return this._size;
            }
            protected set => this._size = value;
        }

        /// <summary>
        ///     Gets the type of the (mime) content.
        /// </summary>
        public virtual string ContentType { get; set; }


        ///// <summary>
        /////     Gets the date the attachment was created.
        ///// </summary>
        ///// <value>The date created.</value>
        //public virtual DateTime? CreatedOnUtc { get; set; }

        ///// <summary>
        /////     Gets the date the attachment was last modified.
        ///// </summary>
        ///// <value>The date modified.</value>
        //public virtual DateTime? LastModifiedOnUtc { get; set; }


        /// <summary>
        ///     Gets or sets the content id that needs to be set if you want to
        ///     embed the file in a message.
        /// </summary>
        public virtual string ContentId { get; set; }


        /// <summary>
        ///     Gets or sets an optional description for this file.
        /// </summary>
        public virtual string Description { get; set; }


        /// <summary>
        ///     Gets or sets the name
        ///     of this media file.
        ///     <para>Member defined in <see cref="IHasNamedValue{TValue}" />.</para>
        /// </summary>
        /// <value>The name.</value>
        public virtual string Name
        {
            get => this._name;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    // ReSharper disable LocalizableElement
                    throw new ArgumentException("String is Null or Empty.", nameof(this.Value));
                    // ReSharper restore LocalizableElement
                }
                this._name = value;
            }
        }

        /// <summary>
        ///     Gets or sets the optional tag for this file.
        /// </summary>
        public virtual string Tag { get; set; }

        /// <summary>
        ///     Gets or sets the value
        ///     of this attachment.
        ///     <para>Member defined in <see cref="IHasNamedValue{TValue}" />.</para>
        /// </summary>
        /// <value>The value.</value>
        public virtual byte[] Value { get; set; }
    }
}