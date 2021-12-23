import { Container, Col, Row, Table, Form, Button } from 'react-bootstrap';
import {DishesForm} from './DishesForm'
import {DishesTable} from './DishesTable'
import { useState, useEffect } from 'react';
import {getDishes, postDish, deleteDish} from '../../Services/DishesService'
import { ProviderComboBox } from './ProvidersComboBox';
import { getUser } from '../../Services/AuthService';

export function DishesPage() {
   const [dishes, setDishes] = useState([]);
   const [selectedProvider, setSelectedProvider] = useState(null);
   let user = getUser();;

       useEffect(() => {
          if(!!selectedProvider)
         getDishes(selectedProvider)
             .then(res => {
               setDishes(u => res.data);
             }).catch( error => console.log(error));
          }, [selectedProvider]);

       const onSubmit = (payload) =>
       {
          console.log(payload);
           postDish(selectedProvider,payload).then(res => {
            setDishes(u => [...u, res.data]);
              }).catch( error => console.log(error));
       };

       const onDeleteAction = (id) =>
       {
          console.log(id);
         deleteDish(selectedProvider,id).then(res => {
               setDishes(u => u.filter(d => d.id != id));
              }).catch( error => console.log(error));
       }

    return (
      <Container className="page-content text-center" >
      <Row>
          <Col className='page-title'>
              Dishes list
          </Col>
      </Row>
      <Row>
         <Col md={{offset: 5, span: 2}}>
            <ProviderComboBox setSelected={setSelectedProvider} selected={selectedProvider}/>
         </Col>
      </Row>
         {selectedProvider && (<><Row>
          <Col  md={{offset: 2, span: 8}} >
              <DishesTable onDelete={onDeleteAction} data={dishes} className='page-table' user={user}/>
          </Col>
      </Row></>)}
      {user?.role === 'Admin' && selectedProvider  && (<>
      <Row>
          <Col md={{offset: 4, span: 4}}>
            <DishesForm onSubmit={onSubmit}/>
          </Col>
      </Row></>)}
      
  </Container>
    );
  }
  