import React,{Component} from 'react';


class LoginForm extends Component{
    constructor(){
        super();
        this.state={
            username:'',
            password:'',
            rol:'',
            firstname:'',
            lastname:''
 
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
    }
    handleSubmit(e){
        e.preventDefault();
        this.props.onValidar(this.state);
        console.log("enviando...");
    }

    render(){
        return(
            <div className="card" >
                <form className="card-body" onSubmit={this.handleSubmit}>
                    <div className="form-group">
                        <input type="text" name="username" className="form-control" placeholder="Username" onChange={this.handleInput}/>
                    </div>
                    <div className="form-group">
                        <input type="password" name="password" className="form-control" placeholder="Password" onChange={this.handleInput}/>
                    </div>

                    <div className="form-group">
                        <input type="submit" value="Login"/>
                        <button onClick={this.props.onIrOlvidoPass}> 
                            Olvido Contraseña
                        </button>
                    </div>
                    <div className="form-group">
                        <label>{this.props.mensaje}</label>
                    </div>
                </form>

            </div>
        )
    }
}
export default LoginForm;