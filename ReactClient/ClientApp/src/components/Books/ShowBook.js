import React, { Component } from 'react'
import { Redirect } from 'react-router-dom'
import { withRouter } from 'react-router-dom';

import './Books.css'

class ShowBook extends Component {
    state = {
        redirect: false
    }

    showBookDetail = () => {
        if (this.props.book) {
            this.setState({ redirect: true })
        }
    }

    render() {
        let book = this.props.book;
        if (this.state.redirect) {
            return <Redirect to={{
                pathname: '/books/' + book.id,
                state: {book}
            }}
            />;
        }
        return (
            <div className="jumbotron" onClick={this.showBookDetail}>
                <span className=''>Title: {book.title}</span>
                <p>Number of copies: {book.numbersOfCopies}</p>
                <img src={book.image} alt="book" className="book-img"></img>
            </div>
        )
    }
   
}

export default withRouter(ShowBook);
