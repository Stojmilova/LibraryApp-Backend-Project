import React, { Component } from 'react'
import './Books.css'

class BookDetail extends Component {
    render() {
        console.log('fbdfbdshfjds')
        return (
            <div className="jumbotron">
                <div className="">
                    <div className="">
                        <span className=''>Title: {this.props.location.state.book.title}</span>
                        <p>Author: {this.props.location.state.book.author}</p>
                        <p>Number of copies: {this.props.location.state.book.numbersOfCopies}</p>
                        <div className='row'>
                            <div className='col s3'>
                                <img src={this.props.location.state.book.image} alt="book" className="book-img"></img>
                            </div>
                            <div className="col s9">
                                <p >Content: {this.props.location.state.book.context}</p>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        )
    }
}

export default BookDetail;
