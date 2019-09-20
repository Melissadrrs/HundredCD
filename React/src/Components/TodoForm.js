import React,{Component} from 'react';

class TodoForm extends Component{
    constructor(){
        super();
        this.state={
            title:'',
            responsible:'',
            description:'',
            priority:'baja'
        };
        this.handleInput=this.handleInput.bind(this);
        this.handleSubmit=this.handleSubmit.bind(this);
        //esto apra q no de error al referenciar el this.state en handleinput, ya q se suele perder el scope y no se sabe de donde es el this.
    }

    handleInput(e){
        // console.log(e.target.value, e.target.name);
        const {value, name}=e.target;
        this.setState({
            [name]:value
        })
        //console.log(this.state);
    }
    handleSubmit(e){
        e.preventDefault();
        this.props.onAddTodo(this.state);
        console.log("enviando...");
    }

    render(){
        return(
            <div className="card">
                <form className="card-body" onSubmit={this.handleSubmit}>
                    <div className="form-group">
                        <input type="text" name="title" className="form-control" placeholder="Title" onChange={this.handleInput}/>
                    </div>
                    <div className="form-group">
                        <input type="text" name="responsible" className="form-control" placeholder="Responsible" onChange={this.handleInput}/>
                    </div>
                    <div className="form-group">
                        <input type="text" name="description" className="form-control" placeholder="Description" onChange={this.handleInput}/>
                    </div>
                    <div className="form-group">
                       <select name="priority" className="form-control" onChange={this.handleInput}>
                            <option>baja</option>
                            <option>alta</option>
                            <option>media</option>
                       </select>
                    </div>
                    <div className="form-group">
                        <input type="submit" value="save"/>
                    </div>
                </form>

            </div>
        )
    }
}
export default TodoForm;