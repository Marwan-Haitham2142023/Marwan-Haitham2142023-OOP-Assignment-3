namespace Collections
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var cases = new (string Input, string Method, bool Expected)[]
            {
                ("01012345678",     "Phone",      true),
                ("+201512345678",   "Phone",      true),
                ("01312345678",     "Phone",      false),
                ("0101234567",      "Phone",      false),
                ("0101234567a",     "Phone",      false),
                ("29901011234567",  "NationalId", true),
                ("19901011234567",  "NationalId", false),
                ("2990101123456",   "NationalId", false),
            };

            foreach (var c in cases)
            {
                var actual = c.Method == "Phone"
                    ? c.Input.IsValidEgyptianPhone()
                    : c.Input.IsValidEgyptianNationalId();

                var status = actual == c.Expected ? "OK" : "FAIL";
                Console.WriteLine($"{status}  {c.Method,-10}  \"{c.Input}\"  expected={c.Expected}  actual={actual}");
            }
        }
    }
}
