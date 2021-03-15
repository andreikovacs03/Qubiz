import * as React from 'react';
import { Session } from '../models/session.model';
import Card from '@material-ui/core/Card';
import CardActions from '@material-ui/core/CardActions';
import CardContent from '@material-ui/core/CardContent';
import Button from '@material-ui/core/Button';
import Typography from '@material-ui/core/Typography';

import './session-card.css';

type Props = {
    session: Session,
    onVote: () => void
}

const SessionCard = (props: Props) => {
    const [votes, setVotes] = React.useState(0);

    const clickVote = () => {
        setVotes(votes + 1);
        props.onVote();
    }

    return (
        <Card className="card">
            <CardContent>
                <Typography variant="h5" component="h2">
                    {props.session.title} <small className="speaker">{" by " + props.session.speaker}</small>
                </Typography>
                <Typography color="textSecondary" gutterBottom>
                    {props.session.room + " - " + props.session.time}
                </Typography>
                <Typography color="textSecondary">

                </Typography>
                <Typography variant="body2" component="p">
                    {props.session.description}
                </Typography>
            </CardContent>
            <CardActions>
                <Button size="small" onClick={clickVote}>Vote👆 ({votes})</Button>
            </CardActions>
        </Card>)
}

export default SessionCard