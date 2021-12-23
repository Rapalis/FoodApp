import { Container, Col, Row, Nav } from 'react-bootstrap';
import {RegisterPanel} from './RegisterPanel';
import { useNavigate } from 'react-router-dom';
import {register} from '../../Services/AuthService'
import { Link } from 'react-router-dom';
import SvgImage from './user.svg'



export function RegisterPage(props) {
    const setUser = props.setUser;
    const navigate = useNavigate();
    const onSubmit = (username,password,email) =>
    {
        register(username,password,email).then(res => {
            navigate("/login");
           }).catch( error => console.log(error));
    };
    return (
    <Container >
        <Row>
            <Col md={{ span: 4, offset: 5 }} >
            <img src={SvgImage} height={200}/>
            </Col>

        </Row>
        <Row>
            <Col md={{ span: 4, offset: 4 }}>
                <RegisterPanel onSubmit={onSubmit}/>
            </Col>
            <Col md={{ span: 4, offset: 4 }}>
                <Nav.Link as={Link} to="login">I already have an account</Nav.Link>
            </Col>
        </Row>
    </Container>
    );
  }
  