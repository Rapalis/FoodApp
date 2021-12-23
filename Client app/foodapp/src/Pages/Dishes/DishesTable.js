import {Table, Button} from 'react-bootstrap';

export function DishesTable(props) {
    const dishes = props.data;
    const onDelete = props.onDelete;
    const user = props.user;
    return (
        
 <Table striped bordered hover>
  <thead>
    <tr>
      <th>Dish name</th>
      <th>Price</th>
      <th>Description</th>
      {user.role === 'Admin' &&<th>Action</th>}
    </tr>
  </thead>
  {dishes.map( p => (<tbody key={p.id}>
    <tr>
      <td>{p.name}</td>
      <td>{p.price}</td>
      <td>{p.description}</td>
      {user.role === 'Admin' &&
      <td><Button variant="danger" onClick={(e) => {onDelete(p.id)}}>X</Button></td>}
    </tr>
  </tbody>))}
  
</Table>

     
    );
  }
  