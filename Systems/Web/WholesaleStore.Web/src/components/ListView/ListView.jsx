import React, { Component } from "react";

export default class ListView extends Component {
    constructor(props){
        super(props);
        this.state = {
            error: null,
            isLoaded: false,
            items: []
        };
    }

    componentDidMount(){
        fetch("http://localhost:5247/v1/Product", {
            headers : { 
                'Content-Type': 'application/json',
                'Accept': 'application/json'
               }
        })
        .then(res => res.json())
        .then(
            (result) => {
                this.setState({
                    isLoaded: true,
                    items: result
                });
            },
            (error) => {
                this.setState({
                    isLoaded: true,
                    error
                })
            }
        )
    }

    render(){
        const { error, isLoaded, items } = this.state;
        if(error){
            return <h6>Error {error.message}</h6>
        } else if (!isLoaded){
            return <p> Loading ... </p>
        } else {
            return (
                <ul>
                    {items.map(item => (
                        <li key={item.id}>
                            {item.title}
                        </li>
                    ))}
                </ul>
            )
        }
    }
}