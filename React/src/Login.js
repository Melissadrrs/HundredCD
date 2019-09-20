import React ,{Component}from 'react';
import logo from './logo.svg';
import './App.css';

import LoginForm from './Components/LoginForm';
import UserForm from './Components/UserForm';
import RecoveryForm from './Components/RecoveryForm';
import axios from 'axios';



class Login extends Component{
  constructor(){
    super();
    this.state={
        mensaje:'',
        Accion:0
    };
    // hereda las funcionalidades de react
    this.handleValidUser=this.handleValidUser.bind(this);
    this.handleIrRegistrar=this.handleIrRegistrar.bind(this);
    this.handleInsertUser=this.handleInsertUser.bind(this);
    this.handleIrOlvidoPass=this.handleIrOlvidoPass.bind(this);
    this.handleVolverHome=this.handleVolverHome.bind(this);
  }

  handleInsertUser(user){
    var value="";
    axios.post('http://localhost:58297/user/insert/',
    
    //"username=" + encodeURIComponent(user.username) 

   JSON.stringify(user),
     {      ContentType: 'application/x-www-form-urlencoded; charset=utf-8',
     dataType: 'json'
    }
    
        
    ).then(result=>{
            value="Éxito";
    }).catch(e => {
            value="Error";
        }).finally(x=>{
            this.setState({

                mensaje:value
            })
        });
    }

  handleValidUser(user){
        var value="";
        axios.post('http://localhost:58297/token',
            "username=" + encodeURIComponent(user.username) +
            "&password=" + encodeURIComponent(user.password) +
            "&grant_type=password"
            ,
            {  
                headers: {'Content-Type': 'application/x-www-form-urlencoded'}
           }
         
        ).then(result=>{
                value="Éxito";
        }).catch(e => {
                value=e.response.data.error_description;
            }).finally(x=>{
                this.setState({
                    mensaje:value
                })
            });
    }

    handleIrRegistrar(e){
        e.preventDefault();
        this.setState({
            Operacion:1
        })
    }

    handleIrOlvidoPass(e){
      this.setState({
          Operacion:2
      })
    } 

    handleVolverHome(e){
      this.setState({
          Operacion:0
      })
    } 

  render(){

    return(
         <div className="App">

              <nav className="navbar navbar-dark bg-dark">
                <a href="" className="text-white">
                    Aplicación Prueba
                    <button className="badge badge-pill badge-light ml-2" onClick={this.handleIrRegistrar}> 
                        Registrar
                    </button>
                </a>

            </nav>
            <div className="container">
                <div className="row mt-4">
                  <img src={logo} className="App-logo" alt="logo" />
                

                  {(() => {
                          switch (this.state.Operacion) {
                            case 1: return <UserForm onRegistrar={this.handleInsertUser}  mensaje={this.state.mensaje}  />;
                            case 2:  return <RecoveryForm  onVolverHome={this.handleVolverHome} />;
                            default:      return <LoginForm onValidar={this.handleValidUser}  mensaje={this.state.mensaje} onIrOlvidoPass={this.handleIrOlvidoPass} />;
                          }
                        })()}
                  
                </div>
             </div>
         </div>
    );
  }
}

export default Login;
