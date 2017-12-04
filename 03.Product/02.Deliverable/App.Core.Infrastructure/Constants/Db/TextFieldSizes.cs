namespace App.Core.Infrastructure.Constants.Db
{
    public static class TextFieldSizes
    {
        private const int basic = 64;

        /// <summary>
        /// 64. Use for Keys, Names
        /// </summary>
        public const int X64 = basic; 
        /// <summary>
        /// 246. Use for FileNames (can be up to 1024, but Indexes must be less than 900 total, so start with this).
        /// </summary>
        public const int X256 = basic*4; //Used for filenames
        
        /// <summary>
        /// Most *system* text should be this...unless user entered.
        /// </summary>
        public const int X1024 = basic*16;
        
        /// <summary>
        /// User Entered Short Descriptions.
        /// </summary>
        public const int X2048 = X1024*32;

        //public const int Max = Int32.MaxValue;
    }
}