import React, { Component } from 'react';
import './IndexView.css';

export class IndexView extends Component {
    static displayName = IndexView.name;

    defaultFilterType = 'Movie';
    apiHeaders = new Headers({ 'Authorization': 'Basic ' + btoa('eja:eja') });
    subtitleMap = { 'Movie': 'Top rated Movies', 'TV Show': 'Top rated TV Shows' };

    titles = [];

    constructor(props) {
        super(props);

        this.state = { items: [], types: [], subtitle: '', selectedTypeName: false, loadingData: true };

        fetch('api/types', {
            headers: this.apiHeaders
        })
        .then(response => response.json())
        .then(data => {
            this.setState({
                types: data
            });
        });

        fetch('api/titles', {
            headers: this.apiHeaders
        })
        .then(response => response.json())
        .then(data => {
            this.titles = data;
            this.setState({
                items: this.getByType(this.defaultFilterType),
                subtitle: this.subtitleMap[this.defaultFilterType],
                selectedTypeName: this.defaultFilterType,
                loadingData: false
            });
        });
    }

    getByType(type) {
        return this.titles.filter(itm => itm.type === type);
    }

    renderByType(typeName = this.defaultFilterType) {
        let _sub = typeof this.subtitleMap[typeName] === 'undefined' ? typeName :
            this.subtitleMap[typeName];

        this.setState({
            items: this.getByType(typeName),
            subtitle: _sub,
            selectedTypeName: typeName,
        });
    }

    static renderItemsTable(items) {
        return (
            <table className='table table-striped'>
                <thead>
                    <tr>
                    <th>Name</th>
                    <th>Released</th>
                    <th>Type</th>
                    </tr>
                </thead>
                <tbody>
                { items.map(itm =>
                    <tr key={itm.id}>
                        <td>{itm.name}</td>
                        <td>{itm.released}</td>
                        <td>{itm.type}</td>
                    </tr>
                )}
                </tbody>
            </table>
        );
    }

    render() {
        let contents = this.state.loadingData ? <p>Loading...</p> : IndexView.renderItemsTable(this.state.items);
        
        return (
            <div className="titles-wrapper">
                <h1>Movie Engine</h1>
                <p>{this.state.subtitle}</p>
                <ul className="nav nav-tabs">
                {this.state.types.map(t =>
                    <li className="nav-item" key={t.name}>
                        <a className={"nav-link " + (t.name === this.state.selectedTypeName ? "active" : "")}
                            onClick={() => this.renderByType(t.name)}>
                            {t.name}
                        </a>
                    </li>
                )}
                </ul>
                <div>{contents}</div>
            </div>
        );
    }
}
