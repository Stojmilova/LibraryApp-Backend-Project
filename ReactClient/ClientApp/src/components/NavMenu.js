import React from 'react';
import { Link } from 'react-router-dom';
import { Glyphicon, Nav, Navbar, NavItem } from 'react-bootstrap';
import { LinkContainer } from 'react-router-bootstrap';
import './NavMenu.css';

export default props => (
  <Navbar inverse fixedTop fluid collapseOnSelect>
    <Navbar.Header>
      <Navbar.Brand>
        <Link to={'/'}><h3><b>iBook</b></h3></Link>
      </Navbar.Brand>
      <Navbar.Toggle />
    </Navbar.Header>
        <Navbar.Collapse>           
      <Nav>
        <LinkContainer to={'/'} exact>
          <NavItem>
            <Glyphicon glyph='home' /> Home
          </NavItem>
        </LinkContainer>
        <LinkContainer to={'/login'}>
          <NavItem>
            <Glyphicon glyph='education' /> Login
          </NavItem>
        </LinkContainer>
        <LinkContainer to={'/register'}>
          <NavItem>
            <Glyphicon glyph='th-list' /> Register
          </NavItem>
                </LinkContainer>
               
      </Nav>
    </Navbar.Collapse>
  </Navbar>
);
