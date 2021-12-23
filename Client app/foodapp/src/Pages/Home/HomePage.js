import { Container, Col, Row } from 'react-bootstrap';
import image from './download.png';

export function HomePage() {
    return (
    <Container className="Body" >
        <Row>
            <Col className='text-center'>
                <span id='fancy'>Here you can order food</span>
            </Col>
        </Row>
        <Row>
            <Col md={{ span: 4, offset: 4 }}>
                <img id='image-contained'  src={image}/>
            </Col>
        </Row>
          
    </Container>
     
    );
  }
  