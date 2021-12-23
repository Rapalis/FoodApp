import { useState } from 'react';
import { Form, Button } from 'react-bootstrap';
//import { From}

export function DishesForm(props) {
    const onSubmit = props.onSubmit;
    const [name, setName] = useState("");
    const [price, setPrice] = useState("");
    const [description, setDesciprtion] = useState("");

    
    const afterSubmit = () => 
    {
        setName("");
        setPrice("");
        setDesciprtion("");
    };

    return (
    <Form onSubmit={(e) => {onSubmit({name: name, price: parseFloat(price), description: description}); afterSubmit(); e.preventDefault();}}>
    <Form.Group className="mb-3">
    <Form.Label>Dish name</Form.Label>
    <Form.Control type="text" placeholder="Enter company name" value={name} onChange={e => setName(e.target.value)}/>
    <Form.Label>Price</Form.Label>
    <Form.Control type="numbers" placeholder="Enter price" value={price} onChange={e => setPrice(e.target.value)}/>
    <Form.Label>Description</Form.Label>
    <Form.Control type="textfield" placeholder="Enter description" value={description} onChange={e => setDesciprtion(e.target.value)}/>
  </Form.Group>

  <Button variant="primary" type="submit" >
    Submit
  </Button>
</Form>
    );
  }
  