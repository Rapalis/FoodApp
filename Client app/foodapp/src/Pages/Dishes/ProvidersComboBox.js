import { useEffect, useState } from 'react';
import {Form} from 'react-bootstrap';
import {getProviders} from '../../Services/ProviderService'

export function ProviderComboBox(props) {
    const [providers, setProviders] = useState([]);
    const setSelected = props.setSelected;
    const selected = props.selected;

    useEffect(() => {
        getProviders()
           .then(res => {
            setProviders(u => res.data);
           }).catch( error => console.log(error));
        }, []);

    const onChange = (e) => 
    {
        setSelected(e.target.value);
    };

    return (
        <Form onChange={onChange}>
        <Form.Select value={selected} placeholder=''>
        {providers.map( p => (<option key={p.id} value={p.id}>{p.name}</option>))}
        </Form.Select>
        </Form> 
     
    );
  }
  