import { useState } from 'react';
import { Form, Button } from 'react-bootstrap';
//import { From}

export function ProvidersForm(props) {
    const onSubmit = props.onSubmit;
    const [companyName, setCompanyName] = useState("");
    const [address, setAddress] = useState("");
    
    const afterSubmit = () => 
    {
        setCompanyName("");
        setAddress("");
    };

    return (
        <Form onSubmit={(e) => {onSubmit({name: companyName, address: address}); afterSubmit(); e.preventDefault();}}>
    <Form.Group className="mb-3">
    <Form.Label>Company name</Form.Label>
    <Form.Control type="text" placeholder="Enter company name" value={companyName} onChange={e => setCompanyName(e.target.value)}/>
    <Form.Label>Address</Form.Label>
    <Form.Control type="text" placeholder="Enter address" value={address} onChange={e => setAddress(e.target.value)}/>
  </Form.Group>

  <Button variant="primary" type="submit" >
    Submit
  </Button>
</Form>
    );
  }
  