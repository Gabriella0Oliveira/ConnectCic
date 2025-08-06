import { BASE_URL } from "./connectCIC_Endpoint";
import { createFetchRequest } from './httpClient'

export const recommendationsService = {
  get: async (projectPrompt) => {
    const payload = {
      projectPrompt: projectPrompt
    }
    const data = await createFetchRequest(`${BASE_URL}/recommendations`, {
        method: 'POST',
        body: JSON.stringify(payload)
    })
    return data
  }
}