import {getClientInstance} from './HttpClient'
import {isExpired} from './AuthService'

export function getProviders()
{
    const client = getClientInstance();
    return client.get('providers');
}

export function postProvider(provider)
{
    const client = getClientInstance();
    return client.post('providers', provider);
}

export function deleteProvider(id)
{
    const client = getClientInstance();
    return client.delete(`providers/${id}`);
}