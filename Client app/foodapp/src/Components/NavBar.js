import { useEffect, useState } from 'react';
import { Navbar, Container, Nav, Col, NavDropdown, Button } from 'react-bootstrap';
import { Link } from 'react-router-dom';
import { getUser } from '../Services/AuthService'
import { logout } from '../Services/AuthService';
import { useNavigate } from 'react-router-dom';

export function NavBar(props) {
  const user = props.user;
  const setUser = props.setUser;
  const navigate = useNavigate();



  const onLogout = () =>
  {
    logout();
    setUser(getUser());
    navigate('/login');
  }

    return (
        <Navbar bg="dark" variant="dark">
        <Container>
          <Navbar.Brand as={Link} to="/">FoodApp</Navbar.Brand>
          <Nav className="me-auto">
            {user.role === 'Admin' && <Nav.Link as={Link} to="providers">Providers</Nav.Link>}
            <Nav.Link as={Link} to="dishes">Dishes</Nav.Link>
            <Nav.Link as={Link} to="reviews">Reviews</Nav.Link>
          </Nav>
          <Nav>
            <Button color="inherit" onClick={onLogout}>Logout</Button>
          </Nav>
        </Container>
      </Navbar>
    );
  }
  