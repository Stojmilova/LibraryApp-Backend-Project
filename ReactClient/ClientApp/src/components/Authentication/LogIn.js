import React, { Component } from 'react'
import './Authentication.css'
import { loginUser } from '../Services/UserService.js';
import { Redirect } from 'react-router-dom'

class LogIn extends Component {
    state = {
        username: '',
        password: '',
        status: 0
    }

    handleChange = (e) => {
        this.setState({
            [e.target.id]: e.target.value
        })
    }

    validateForm = () => {
        return this.state.username.length > 0 && this.state.password.length > 0;
    }

    handleSubmit = (e) => {
        e.preventDefault();
        //let credentials = this.state;
        loginUser(this.state).then(response => {
            this.setState({status: response})
        });     
        this.setState({
            username: '',
            password: ''
        });
        this.usernameInput.value = "";
        this.passwordInput.value = "";
    }

    render() {
        const userStatus = this.state.status;
        console.log(userStatus);
        if(userStatus === 200 ) return <Redirect to='/books'></Redirect>
        return (
            <div className="container auth-form">
                <div className="row">
                    <div className="col-sm-4">
                        <form>
                            <div className="auth-title">Login</div>
                            <div className="form-group">
                                <label htmlFor="username" className="auth-label">Username:</label>
                                <input ref={(ref) => this.usernameInput = ref} type="text" className="form-control " id="username" placeholder="Enter username..." onChange={this.handleChange}/>
                               
                            </div>
                            <div className="form-group">
                                <label htmlFor="password" className="auth-label">Password:</label>
                                <input ref={(ref) => this.passwordInput = ref} type="password" className="form-control" id="password" placeholder="Enter password..." onChange={this.handleChange}/>
                            </div>
                            <button type="submit" className="btn btn-primary auth-btn" disabled={!this.validateForm()} onClick={this.handleSubmit}>Login</button>
                        </form>
                    </div>
                    <div className="col-sm-8"></div>
                </div>
            </div>
        );
    }
}


export default LogIn
