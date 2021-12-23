import './App.css';
import { Col, Container, Row } from 'react-bootstrap';
import { Header } from './Components/Header.js';
import { Body } from './Pages/Home/HomePage.js';
import { Footer } from './Components/Footer.js';
import {getUser} from './Services/AuthService';
import {useState} from 'react';
import * as Pages  from './Pages';
import { useLocation } from 'react-router-dom'


function App(props) {
  const location = useLocation();
  console.log(location.pathname);
  const [user, setUser] = useState(getUser());
   const [wanaRegister, setWanaRegister] = useState(false);
  return (
    !!user ? (<Container fluid>
      <Row>
        <Header user={user} setUser={setUser}/>
      </Row>
      <Row className='body'>
            {props.children}
      </Row>
      <Row>
        <Footer/>
      </Row>
    </Container>) : location.pathname === '/login' ? <Pages.LoginPage setWanaRegister={setWanaRegister} setUser={setUser}/> : 
    <Pages.RegisterPage setWanaRegister={setWanaRegister} setUser={setUser}/>
    
  );
}

export default App;
