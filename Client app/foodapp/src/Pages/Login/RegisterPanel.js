import { Container, Form, Button} from 'react-bootstrap';
import { useState } from 'react';


export function RegisterPanel(props) {
  const onSubmit = props.onSubmit;
  const [username, setUsername] = useState("");
  const [password, setPassword] = useState("");
  const [email, setEmail] = useState("");

    return (
<Form onSubmit={(e) => {onSubmit(username,password,email); e.preventDefault();}}>
  <Form.Group className="mb-3" controlId="formBasicEmail">
    <Form.Label>Username</Form.Label>
    <Form.Control type="text" placeholder="Enter username" value={username} onChange={e => setUsername(e.target.value)}/>
  </Form.Group>

  <Form.Group className="mb-3" controlId="formBasicPassword">
    <Form.Label>Password</Form.Label>
    <Form.Control type="password" placeholder="Password" value={password} onChange={e => setPassword(e.target.value)}/>
  </Form.Group>

  <Form.Group className="mb-3" >
    <Form.Label>Email</Form.Label>
    <Form.Control type="email" placeholder="Email" value={email} onChange={e => setEmail(e.target.value)}/>
  </Form.Group>
  <Button variant="primary" type="submit" >
    Register
  </Button>
</Form>
    );
  }
  