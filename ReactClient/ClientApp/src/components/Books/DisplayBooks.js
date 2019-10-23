import React, { Component } from 'react';
import { getAllBooks } from '../Services/BookService.js';
import ShowBook from './ShowBook';

class DisplayBooks extends Component {
    state = {
        books: []
    }

    componentDidMount() {
        getAllBooks().then(response => {
            this.setState({ books: response })
        });
    };

    render() {
        let books = this.state.books;
        return (
            <div className='' >
                {books && books.map(book => {
                    return (
                        <div className="" key={book.id}>
                            <ShowBook book={book} key={book.id} />
                        </div>
                    )
                })
                }
            </div>
        )
    }
}

export default DisplayBooks;
