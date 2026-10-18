
## Reports — Template Method

### What the refactor does

Before, `CsvReportExporter`, `JsonReportExporter`, and `TextReportExporter`
each had their own copy of the same steps:

1. Build the report (header, then rows, then footer).
2. Write it to a file.

Only the formatting was different. Everything else was duplicated three times.

Now the shared steps live in one abstract base class, `ReportExporter`. The
base class owns the order of steps. The subclasses only fill in the parts that
are different.

- `ReportExporter` — owns the flow: build → write.
- `CsvReportExporter` — only knows CSV formatting.
- `JsonReportExporter` — only knows JSON formatting.
- `TextReportExporter` — only knows plain-text formatting.

The output files are still the same as before. Only the code structure changed.

### Why an abstract class is a better fit than an interface here

1. **We need to share real code, not just method names.**
   An interface can only say which methods must exist. It cannot contain the
   working `BuildReport` loop or the `File.WriteAllText` call. With an
   interface, every exporter would copy that shared code again — the exact
   duplication we are removing. The abstract class lets us write it once.

2. **We need the step order to be fixed.**
   The whole point of the template method is that the order
   (header → rows → footer → write) is decided once, in the base class.
   An interface cannot enforce any order. An implementer could do the steps
   in the wrong order or skip one.

4. **The base class can hold shared state and helpers.**
   A `StringBuilder`, a delimiter, a config value — all easy in a class.
   An interface cannot hold state.

5. **It is a real "is-a" relationship.**
   A `CsvReportExporter` **is a** `ReportExporter`. That is exactly what
   inheritance is for.


**Rule of thumb:** use an interface when unrelated types share a contract.
Use an abstract class with a template method when related types share an
algorithm whose steps vary. The three exporters share one algorithm, so an
abstract class is the right tool.                                                 =>       **AI Generated**

---

## Enrollment — Facade

### What problem the Facade solves here

Before the refactor, `Program.cs` had to:

1. Create four services: `PaymentGateway`, `SeatInventory`,
   `InvoiceGenerator`, `EmailService`.
2. Call them in the correct order: charge → reserve seat → create invoice →
   send email.
3. Remember to take the invoice ID from `InvoiceGenerator` and pass it into
   the email body.

That is a lot of workflow detail sitting in the caller. `Program.cs` should
not have to know how enrollment works internally — it should just ask for an
enrollment.

The Facade solves this by putting the whole flow inside one class,
`EnrollmentFacade`. The caller now makes one call:

```csharp
var enrollment = new EnrollmentFacade();
enrollment.Enroll(studentId, courseId, amount);