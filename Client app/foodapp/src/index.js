import React from 'react';
import ReactDOM from 'react-dom';
import './index.css';
import App from './App';
import {Home} from './Pages/Home/HomePage';
import { BrowserRouter, Routes, Route } from "react-router-dom";
import * as Pages  from './Pages';


import 'bootstrap/dist/css/bootstrap.min.css';

ReactDOM.render(
    <BrowserRouter>
      <App>
          <Routes>
            <Route path="/" element={<Pages.HomePage/>} />
            <Route path="providers" element={<Pages.ProvidersPage />} />
            <Route path="dishes" element={<Pages.DishesPage />} />
            <Route path="reviews" element={<Pages.ReviewsPage />} />
            <Route path="register" element={<Pages.RegisterPage />} />
            <Route path="login" element={<Pages.LoginPage />} />
          </Routes>
      </App>
    </BrowserRouter>,
  document.getElementById('root')
);
