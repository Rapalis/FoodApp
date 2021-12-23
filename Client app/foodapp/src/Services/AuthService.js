import {getClientInstance} from './HttpClient'
const axios = require('axios').default;

//let user = null;
//let expiration = null;

export async function login(user, pass)
{
    const client = getClientInstance();
    const token = (await client.post('login', {UserName: user, Password: pass})).data.accessToken;
    const parsedData = parseJwt(token);
    user = {username: parsedData['http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name'], role: parsedData['http://schemas.microsoft.com/ws/2008/06/identity/claims/role'], id: parsedData.userId};
    client.defaults.headers.common['Authorization'] = `Bearer ${token}`;
    localStorage.setItem("accessToken", token);
    return user;
}

export function register(user, pass, email)
{
    console.log(email);
    const client = axios.create({
        baseURL: 'https://foddappapi.azurewebsites.net/api/v1/',
        timeout: 5000 });


    return client.post('register', {username: user, password: pass, email: email});
}


export function getUser()
{
    let parsedData = localStorage.getItem("accessToken");
    if(parsedData === "")
        return null;
        
    parsedData = parseJwt(parsedData);
    const user = {username: parsedData['http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name'], role: parsedData['http://schemas.microsoft.com/ws/2008/06/identity/claims/role'], id: parsedData.userId};

    return user;
}

export function logout()
{
    const parsedData = localStorage.setItem("accessToken", "");
} 

export function isExpired()
{
    return false;
}

function parseJwt (token) {
    var base64Url = token.split('.')[1];
    var base64 = base64Url.replace(/-/g, '+').replace(/_/g, '/');
    var jsonPayload = decodeURIComponent(atob(base64).split('').map(function(c) {
        return '%' + ('00' + c.charCodeAt(0).toString(16)).slice(-2);
    }).join(''));

    return JSON.parse(jsonPayload);
};