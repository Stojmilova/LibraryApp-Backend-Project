export function getAllBooks() {
    return fetch("http://localhost:60937/api/book")
        .then(result => {
        return result.json();
        }).then(response => response)
        .then(response => {
            return response;
        })
        .catch(error => console.warn(error));
}

export default getAllBooks;
