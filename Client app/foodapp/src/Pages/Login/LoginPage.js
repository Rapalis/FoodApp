import { Container, Col, Row, Nav } from 'react-bootstrap';
import {LoginPanel} from './LoginPanel.js';
import { useNavigate } from 'react-router-dom';
import {login} from '../../Services/AuthService'
import { Link } from 'react-router-dom';
import SvgImage from './user.svg'


export function LoginPage(props) {
    const setUser = props.setUser;
    const navigate = useNavigate();
    const onSubmit = (username,password) =>
    {
        login(username,password).then(res => {
            setUser(res);
            navigate("/");
           }).catch( error => console.log(error));
    };
    return (
    <Container className="login-panel" >
        <Row>
            <Col md={{ span: 4, offset: 5 }} >
            <img src={SvgImage} height={200}/>
            </Col>

        </Row>
        <Row>
            <Col md={{ span: 4, offset: 4 }}>
                <LoginPanel onSubmit={onSubmit}/>
            </Col>
            <Col md={{ span: 4, offset: 4 }}>
                <Nav.Link as={Link} to="register">Don't have an account?</Nav.Link>
            </Col>
        </Row>
    </Container>
    );
  }
  