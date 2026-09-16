import { mockApi } from '../mocks/mockApi.js'

// VITE_USE_MOCK_API keeps this personal repository usable before the assigned feature is complete.
// Set it to false when testing the real ASP.NET Core integration.
export async function api(path, options = {}) {
  if (import.meta.env.VITE_USE_MOCK_API === 'true') return mockApi(path, options)
  const response = await fetch(`/api${path}`, {
    credentials: 'include',
    headers: { 'Content-Type': 'application/json', ...options.headers },
    ...options
  })
  if (response.status === 204) return null
  const data = await response.json().catch(() => null)
  if (!response.ok) throw new Error(data?.message || 'Noe gikk galt. Prøv igjen.')
  return data
}
