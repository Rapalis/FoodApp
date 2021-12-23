const axios = require('axios').default;

let clientInstance = null;

export function getClientInstance()
{
    const token = `Bearer ${localStorage.getItem("accessToken")}`;

        clientInstance = axios.create({
            baseURL: 'https://foddappapi.azurewebsites.net/api/v1/',
            timeout: 5000,
            headers: {'Content-Type': 'application/json',
            'Authorization': token}});

    return clientInstance;
}
