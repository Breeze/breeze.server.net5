namespace System.Transactions
{
#if DNXCORE50
    // Summary:
    //     Contains additional information that specifies transaction behaviors.
    //     WB: This will never actually work. Kept as much of definition as needed to get this to compile
    public struct TransactionOptions
    {

        // Summary:
        //     Returns a value that indicates whether two System.Transactions.TransactionOptions
        //     instances are not equal.
        //
        // Parameters:
        //   x:
        //     The System.Transactions.TransactionOptions instance that is to the left of
        //     the equality operator.
        //
        //   y:
        //     The System.Transactions.TransactionOptions instance that is to the right
        //     of the equality operator.
        //
        // Returns:
        //     true if x and y are not equal; otherwise, false.
        //public static bool operator !=(TransactionOptions x, TransactionOptions y);
        //
        // Summary:
        //     Tests whether two specified System.Transactions.TransactionOptions instances
        //     are equivalent.
        //
        // Parameters:
        //   x:
        //     The System.Transactions.TransactionOptions instance that is to the left of
        //     the equality operator.
        //
        //   y:
        //     The System.Transactions.TransactionOptions instance that is to the right
        //     of the equality operator.
        //
        // Returns:
        //     true if x and y are equal; otherwise, false.
        //public static bool operator ==(TransactionOptions x, TransactionOptions y);

        // Summary:
        //     Gets or sets the isolation level of the transaction.
        //
        // Returns:
        //     A System.Transactions.IsolationLevel enumeration that specifies the isolation
        //     level of the transaction.
        public IsolationLevel IsolationLevel { get; set; }
        //
        // Summary:
        //     Gets or sets the timeout period for the transaction.
        //
        // Returns:
        //     A System.TimeSpan value that specifies the timeout period for the transaction.
        public TimeSpan Timeout { get; set; }

        // Summary:
        //     Determines whether this System.Transactions.TransactionOptions instance and
        //     the specified object are equal.
        //
        // Parameters:
        //   obj:
        //     The object to compare with this instance.
        //
        // Returns:
        //     true if obj and this System.Transactions.TransactionOptions instance are
        //     identical; otherwise, false.
        //public override bool Equals(object obj);
        //
        // Summary:
        //     Returns the hash code for this instance.
        //
        // Returns:
        //     A 32-bit signed integer hash code.
        //public override int GetHashCode();
    }
#endif
}
