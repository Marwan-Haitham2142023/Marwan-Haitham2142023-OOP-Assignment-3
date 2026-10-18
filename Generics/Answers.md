# Answers.md

## Step 1 & Step 2 — Student Store vs. Course Store

### Implementation summary

Both stores expose the same four operations over an internally-held `List<T>`:

- `AddCourse(Course course)` — appends the course to the internal list.
- `GetById(int id)` — returns the matching course, or `null` if not found.
- `GetAll()` — returns the internal list.
- `RemoveCourse(int id)` — finds by `Id` and removes it if present (null-safe).

> Note: this store uses `courses.Find(c => c.Id == id)` rather than `FirstOrDefault(...)`. `List<T>.Find` returns `null` for reference types when no match is found, so `Course?` is still correct.

---

### What is the same between the two stores

1. **Same internal storage shape** — both wrap a `List<T>` in a private backing field (`courses` / `students`).
2. **Same four operations** — add, get-all, get-by-id, remove-by-id — with the same signatures apart from the element type.
3. **Same lookup logic** — `GetById` searches by `Id` and returns `null` when nothing matches (via `Find` / `FirstOrDefault`).
4. **Same removal logic** — `RemoveCourse` / `RemoveStudent` looks up by `Id` first, then removes only if found (null-safe).
5. **Same contract assumption** — both assume the entity exposes an `int Id` that uniquely identifies a record.
6. **Same return types** — `void`, nullable entity (`T?`), `List<T>`, `void`.

In short: the **algorithm is duplicated almost verbatim**; only the type name and method names change.

### What is different between the two stores

1. **The element type** — `Student` vs `Course`. This is the only *semantic* difference.
2. **The entity's other properties** — `Student` has `Name` (string); `Course` has `Title` (string) and `Price` (decimal). Neither store touches these, but they define what the entity "is."
3. **The field/method names** — `courses` vs `students`, `AddCourse` vs `AddStudent`, `RemoveCourse` vs `RemoveStudent` (cosmetic only).
4. **The identifier semantics** — both use `int Id`, so at the store level there is no difference; the difference is only in *what* the `Id` refers to (a student vs. a course).
