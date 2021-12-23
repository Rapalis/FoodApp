import { Container, Col, Row, Table, Form, Button } from 'react-bootstrap';
import {ProvidersForm} from './ProvidersForm'
import {ProvidersTable} from './ProvidersTable'
import { useState, useEffect } from 'react';
import {getProviders, postProvider, deleteProvider} from '../../Services/ProviderService'



export function ProvidersPage() {
    const [providers, setproviders] = useState([]);
    useEffect(() => {
        getProviders()
           .then(res => {
            setproviders(u => res.data);
           }).catch( error => console.log(error));
        }, []);

        const onDeleteAction = (id) =>
        {
            deleteProvider(id).then(res => {
                setproviders(u => u.filter(d => d.id != id));
               }).catch( error => console.log(error));
        }

        const onSubmit = (payload) =>
        {
            console.log(payload);
            postProvider(payload).then(res => {
                setproviders(u => [...u, res.data]);
               }).catch( error => console.log(error));
        };
    return (
    <Container className="page-content text-center" >
        <Row>
            <Col className='page-title'>
                Food provideres list
            </Col>
        </Row>
        <Row>
            <Col  md={{offset: 2, span: 8}} >
                <ProvidersTable data={providers} onDelete={onDeleteAction} className='page-table'/>
            </Col>
        </Row>
        <Row>
            <Col md={{offset: 4, span: 4}}>
                <ProvidersForm onSubmit={onSubmit}/>
            </Col>
        </Row>
    </Container>
     
    );
  }
  