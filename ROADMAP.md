# Roadmap - Tasks 1, 2 and 8

This roadmap is ordered so you can work asynchronously. Finish and commit one checkpoint at a time. Do not wait for another task holder; all required contracts already exist in this repository.

## Checkpoint 0 - Understand the supplied system

Trace these flows before editing:

```text
AuthPage -> AuthContext -> authApi -> apiClient -> AuthController -> AuthService -> AppDbContext -> User
React page -> API module -> Controller -> Service -> EF Core -> SQLite
```

The browser sends JSON to controller routes. Controllers translate HTTP concerns. Services implement rules. EF Core persists models in SQLite. React renders returned DTOs.

Deliverable: add a short note to your work log explaining Model, View and Controller in this project.

## Checkpoint 1 - Task 1 coordination foundation

1. Use one branch per focused change: `auth/service`, `auth/controller`, `docs/architecture`.
2. Keep commits small and descriptive.
3. Record any route, DTO or model change in `docs/INTEGRATION_NOTES.md`.
4. Before the weekly meeting, prepare a short status: completed, next, blocker, contract change.
5. During the later shared-repository merge, integrate data access before controllers, controllers before AJAX, and AJAX before final UI testing.

Acceptance evidence: branch list, clean commits, build result and an updated integration note.

## Checkpoint 2 - Task 2 writing foundation

Create `docs/REPORT_DRAFT.md` with these sections:

1. Introduction and problem statement.
2. Requirements and the single `User` role.
3. Architecture: React View, ASP.NET Core Controller, service layer, EF Core Model and SQLite.
4. Data flow examples for authentication, quiz CRUD and gameplay.
5. Local deployment and technology choices.
6. Evaluation, limitations and individual contributions.

Write decisions while coding. Ask each member for one short subsection containing implementation, alternatives, testing and limitations. Merge their writing without rewriting technical claims you cannot verify.

## Checkpoint 3 - Implement registration in AuthService

File: `server/BecomeAWizzard.Api/Services/AuthService.cs`

Algorithm:

1. Trim and lowercase the e-mail.
2. Query `db.Users` for duplicates.
3. Create `User` with trimmed display name and normalized e-mail.
4. Hash the password with `PasswordHasher<User>`.
5. Add the user and call `SaveChangesAsync`.
6. Return the stored user.

The dependency direction is important: `AuthController` calls `AuthService`; the service calls `AppDbContext`. Do not access EF Core directly from the React client or controller.

Test duplicate e-mail using different casing and spaces.

## Checkpoint 4 - Implement login validation

File: `server/BecomeAWizzard.Api/Services/AuthService.cs`

1. Normalize the incoming e-mail exactly as registration does.
2. Use `SingleOrDefaultAsync` to locate the user.
3. Verify with `PasswordHasher<User>.VerifyHashedPassword`.
4. Return the user on success and `null` on failure.

Do not reveal whether the e-mail or password was wrong. Do not log the password.

## Checkpoint 5 - Implement the HTTP authentication flow

Files: `AuthController.cs` and `Program.cs`.

1. Register/login call `AuthService` and map `User` to `UserDto`.
2. Create claims for identifier, display name, e-mail and XP.
3. Create a `ClaimsIdentity` using the cookie scheme.
4. Call `HttpContext.SignInAsync`.
5. Add `[Authorize]` to `me` and `logout`.
6. `me` reads claims; logout calls `SignOutAsync` and returns 204.
7. Confirm cookie redirects become HTTP 401 for API clients.

Keep the existing route contract because `authApi.js` already depends on it.

## Checkpoint 6 - Connect React authentication

Files: `authApi.js`, `AuthContext.jsx`, `AuthPage.jsx`.

1. Set `VITE_USE_MOCK_API=false` only after the backend endpoints work.
2. Confirm all requests include `credentials: 'include'` through `apiClient.js`.
3. On application load, call `me()` and finish the loading state even on 401.
4. Login/register update the shared user state.
5. Logout clears the state only after the server request succeeds.
6. Display server-safe error text in the form.

## Checkpoint 7 - Verification

Run and record:

- valid registration;
- invalid e-mail and short password;
- duplicate e-mail;
- wrong password;
- session survives refresh;
- unauthenticated protected request returns 401;
- logout removes access;
- frontend production build;
- backend Release build.

Do not test with real passwords or personal e-mail addresses.

## Checkpoint 8 - Weekly handoff package

Prepare only material that the shared repository needs:

- completed authentication files;
- any required `Program.cs` changes;
- documentation sections;
- test evidence;
- concise integration notes.

Do not copy `client/src/mocks/mockApi.js` as a finished feature. During the weekly meeting, resolve contract conflicts first and visual conflicts last.
