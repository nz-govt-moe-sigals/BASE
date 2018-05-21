// Extensions are always put in root namespace
// for maximum usability from elsewhere:

namespace App
{
    public static class IntegerExtensions
    {
        public static bool BitIsSet(this int number, int checkNumber)
        {
            return (number & checkNumber) == checkNumber;
        }

        /// <summary>
        ///     <para>
        ///         An XActLib Extension.
        ///     </para>
        ///     Bits the is not set.
        ///     <para>
        ///         ie: <c>(number &amp; (~flags)) == 0</c>
        ///     </para>
        ///     <para>
        ///         If you want to set it, try: <c>number | flags</c>
        ///     </para>
        ///     <para>
        ///         If you want to clear a flag, try: <c>number &amp; (~flags)</c>
        ///     </para>
        /// </summary>
        /// <param name="number">The number.</param>
        /// <param name="flags">The flags.</param>
        /// <returns></returns>
        /// <internal>
        ///     <para>6/11/2011: Sky</para>
        /// </internal>
        public static bool BitIsNotSet(this int number, int flags)
        {
            return (number & ~flags) == 0;
        }

        public static int BitSet(this int number, int flags)
        {
            return number | flags;
        }

        public static int BitClear(this int number, int flags)
        {
            return number & ~flags;
        }

        ///// <summary>
        ///// Converts an integer to a Guid unique identifier
        ///// (obviously not very random).
        ///// <para>
        ///// Useful for initial seeding scenarios.
        ///// </para>
        ///// </summary>
        ///// <returns></returns>
        //public static Guid ToGuid(this int value)
        //{
        //    byte[] bytes = new byte[16];
        //    BitConverter.GetBytes(value).CopyTo(bytes, 0);
        //    return new Guid(bytes);
        //}
    }
}