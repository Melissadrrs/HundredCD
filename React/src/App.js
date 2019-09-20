import React ,{Component}from 'react';
import logo from './logo.svg';
import './App.css';

// function App() {
//   return (
//     <div className="App">
//           <h1 className="display-1">Navegación</h1>
//           <img src={logo} className="App-logo" alt="logo" />
//         </div>
//         /* <header className="App-header">
//         <img src={logo} className="App-logo" alt="logo" />
//         <p>
//           Edit <code>src/App.js</code> and save to reload.
//         </p>
//         <a
//           className="App-link"
//           href="https://reactjs.org"
//           target="_blank"
//           rel="noopener noreferrer"
//         >
//           Hola mundo meli
//         </a>
//       </header>
//       <p className="App-intro">
//         contenido
//       </p> */


//   );
// }

import Navigation from './Components/Navigation';
import TodoForm from './Components/TodoForm';
import { todos } from './todos.json'

console.log(todos);
class App extends Component{
  constructor(){
    super();
    // hereda las funcionalidades de react
    this.state={
      // title: 'Aplicacion de Tareas',
      // ntareas:10
      todos
    }
    this.handleAddTodo=this.handleAddTodo.bind(this);
  }
 

  handleAddTodo(todo){
    this.setState({
        todos:[...this.state.todos,todo]
        //Se agrega el todo al arreglo de todos
        })
  }
  render(){
    console.log(this.state.todos);

    const todos=this.state.todos.map((todo,i)=>{
        return (
          <div className="col-md-4">
          <div className="card mt-4">
            <div className="card-header">
                <h3>{todo.title}</h3>
                <span className="badge badge-pill badge-danger ml-2">
                {todo.priority}
                </span>
            </div>
            <div className="card-body">
                <p>{todo.description}</p>
                <p><mark>{todo.responsible}</mark></p>
            </div>             
          </div>
          </div>
        )
    })
    return(
         <div className="App">
              {/* <Navigation Titulo="Tareas"/> */}
              
              <nav className="navbar navbar-dark bg-dark">
                <a href="" className="text-white">
                    Task
                    <span className="badge badge-pill badge-light ml-2"> 
                    {this.state.todos.length}
                    </span>
                </a>

            </nav>
            <div className="container">
              <div className="row mt-4">
              {todos}
              </div>
                <div className="row mt-4">
                  <img src={logo} className="App-logo" alt="logo" />
                  <TodoForm onAddTodo={this.handleAddTodo}/>
                  </div>
             </div>
         </div>
    );
  }
}

export default App;
