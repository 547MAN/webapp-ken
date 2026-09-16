# Become a Wizzard - Kenneth's independent workspace

This repository is a runnable learning environment for **Kenneth Skinland**.

## Prerequisites

- .NET 10 SDK
- Node.js 20 or newer
- npm

## Your responsibility

- **Task 1:** coordinate coding and the later merge into the separate shared repository.
- **Task 2:** coordinate writing; own the introduction and architecture sections.
- **Task 8:** write and code authentication.

The quiz, game, data-access, AJAX and finished UI areas are supplied as supporting code. Authentication contains starter code and TODO markers instead of the finished solution.

## Start without waiting for the group

The frontend starts in mock mode, so the visual application works before real authentication is complete.

```bash
cd client
npm ci
npm run dev
```

Open `http://localhost:5173`. Mock mode is controlled by `client/.env.development`.

When authentication is ready:

1. Start the API with `dotnet run --project server/BecomeAWizzard.Api`.
2. Change `VITE_USE_MOCK_API=false`.
3. Restart Vite and test registration, login, refresh, `/api/auth/me` and logout.

## Start here

Read [ROADMAP.md](ROADMAP.md), then work through TODOs in this order:

1. `server/BecomeAWizzard.Api/Services/AuthService.cs`
2. `server/BecomeAWizzard.Api/Controllers/AuthController.cs`
3. `server/BecomeAWizzard.Api/Program.cs`
4. `client/src/api/authApi.js`
5. `client/src/context/AuthContext.jsx`
6. `client/src/pages/AuthPage.jsx`
7. Documentation and merge checklist

## Important boundaries

- Do not change quiz/game DTO fields or routes unless the whole group agrees.
- Do not implement a second user role; the project has one general `User` role.
- Never store clear-text passwords.
- The temporary file `client/src/mocks/mockApi.js` is only an independence aid and is not final authentication.

## Definition of done

- Registration stores a unique normalized e-mail and a password hash.
- Login creates a secure local cookie and invalid credentials return 401.
- `/api/auth/me` restores the session after a browser refresh.
- Logout invalidates the session.
- Protected routes reject unauthenticated requests without redirecting to HTML.
- README/report sections explain MVC, architecture, setup and important decisions.
- A final merge checklist records routes, DTOs, database changes and verification results.
