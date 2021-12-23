import {getClientInstance} from './HttpClient'

export function getDishes(providerId)
{
    const client = getClientInstance();
    return client.get(`providers/${providerId}/dishes`);
}

export function postDish(providerId, dish)
{
    const client = getClientInstance();
    return client.post(`providers/${providerId}/dishes`, dish);
}

export function deleteDish(providerId, id)
{
    const client = getClientInstance();
    return client.delete(`providers/${providerId}/dishes/${id}`);
}