import {Container, Row } from 'react-bootstrap';
import { NavBar} from './NavBar.js';
import image from './headerImage.jpg'

export function Header(props) {
    const user = props.user;
    const setUser = props.setUser;
    return (
        <NavBar user={user} setUser={setUser}/>
    );
  }
  