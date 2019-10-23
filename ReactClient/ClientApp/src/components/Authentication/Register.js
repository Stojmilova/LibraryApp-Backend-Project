import React, { Component } from 'react'
import { registerUser } from '../Services/UserService.js';
import { Redirect } from 'react-router-dom'
import './Authentication.css'

class Register extends Component {
    state = {
        firstName: '',
        lastName: '',
        username: '',
        password: '',   
        confirmPassword: '',
        status: 0
    }

    handleChange = (e) => {
        this.setState({
            [e.target.id]: e.target.value
        })
    }

    handleSubmit = (e) => {
        e.preventDefault();
        //let credentials = this.state;
        registerUser(this.state).then(response => {
            this.setState({ status: response })
        });
        this.setState({
            firstName: '',
            lastName: '',
            username: '',
            password: '',
            confirmPassword: ''
        })
        this.firstNameInput.value = "";
        this.lastNameInput.value = "";
        this.usernameInput.value = "";
        this.passwordInput.value = "";
        this.confirmPasswordInput.value = "";
    }

    validateForm = () => {
        return this.state.username.length > 0
            && this.state.password.length > 0
            && this.state.password === this.state.confirmPassword
            && this.state.firstName.length > 0
            && this.state.lastName.length > 0;
    }

    render() {
        const userStatus = this.state.status;
        console.log(userStatus);
        if (userStatus === 200) return <Redirect to='/login'></Redirect>
        return (
            <div className="container auth-form">
                <div className="row">
                    <div className="col-sm-4">
                        <form>
                            <div className="auth-title">Registration form</div>
                            <div className="form-group">
                                <label htmlFor="firstName" className="auth-label">First name:</label>
                                <input ref={(ref) => this.firstNameInput = ref} type="text" className="form-control" id="firstName" placeholder="Enter first name..." onChange={this.handleChange} />
                            </div>
                            <div className="form-group">
                                <label htmlFor="lastName" className="auth-label">Last name:</label>
                                <input ref={(ref) => this.lastNameInput = ref} type="text" className="form-control" id="lastName" placeholder="Enter last name..." onChange={this.handleChange} />
                            </div>
                            <div className="form-group">
                                <label htmlFor="username" className="auth-label">Username:</label>
                                <input ref={(ref) => this.usernameInput = ref} type="text" className="form-control " id="username" placeholder="Enter username..." onChange={this.handleChange} />
                            </div>
                            <div className="form-group">
                                <label htmlFor="password" className="auth-label">Password:</label>
                                <input ref={(ref) => this.passwordInput = ref} type="password" className="form-control" id="password" placeholder="Enter password..." onChange={this.handleChange} />
                            </div>
                            <div className="form-group">
                                <label htmlFor="confirmPassword" className="auth-label">Confirm password:</label>
                                <input ref={(ref) => this.confirmPasswordInput = ref} type="password" className="form-control" id="confirmPassword" placeholder="Confirm password..." onChange={this.handleChange} />
                            </div>
                            <button type="submit" className="btn btn-primary auth-btn" onClick={this.handleSubmit}>Register</button>
                        </form>
                    </div>
                    <div className="col-sm-8"></div>
                </div>
            </div>
        )
    }
}

export default (Register)