import { useState, useEffect } from 'react';
import {Table, Button} from 'react-bootstrap';

export function ProvidersTable(props) {
    const providers = props.data;
    const onDelete = props.onDelete;


    return (
        
 <Table striped bordered hover>
  <thead>
    <tr>
      <th>Company name</th>
      <th>Address</th>
      <th>Action</th>
    </tr>
  </thead>
  {providers.map( p => (<tbody key={p.id}>
    <tr>
      <td>{p.name}</td>
      <td>{p.address}</td>
      <td><Button variant="danger" onClick={(e) => {onDelete(p.id)}}>X</Button></td>
    </tr>
  </tbody>))}
  
</Table>

     
    );
  }
  