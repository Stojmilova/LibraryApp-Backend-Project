export function loginUser(credentials){
    var data = {
        "username": credentials.username,
        "password": credentials.password
    }

    return fetch("http://localhost:60937/api/user/authenticate", {
        method: "POST",
        headers: {
            'Accept': 'application/json',
            'Content-type': 'application/json',
        },
        body: JSON.stringify(data)
    }).then(response => response)
        .then(response => {
            console.log(response.status);
            return response.status;
        })
        .catch(error => console.warn(error));
};

export function registerUser(credentials) {
    var data = {
        "firstName": credentials.firstName,
        "lastName": credentials.lastName,
        "username": credentials.username,
        "password": credentials.password,
        "confirmPassword": credentials.confirmPassword
    }

    return fetch("http://localhost:60937/api/user/register", {
        method: "POST",
        headers: {
            'Accept': 'application/json',
            'Content-type': 'application/json',
        },
        body: JSON.stringify(data)
    }).then(response => response)
        .then(response => {
            console.log(response.status);
            return response.status;
        })
        .catch(error => console.warn(error));
};

export default loginUser;



