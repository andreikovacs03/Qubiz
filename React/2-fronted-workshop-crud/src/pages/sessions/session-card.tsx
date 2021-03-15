import * as React from 'react';
import Card from '@material-ui/core/Card';
import { CardActions, CardContent, Typography, Button, CardActionArea} from '@material-ui/core/';
import { Session } from 'shared/models/session.model';
import DeleteIcon from '@material-ui/icons/Delete';
import SearchIcon from '@material-ui/icons/Search';
import ThumbUpIcon from '@material-ui/icons/ThumbUp';
import { Link } from 'react-router-dom';
import { red } from '@material-ui/core/colors';
import './session-card.css';
import EditForm from './session-card-edit-form';

type Props = {
    session: Session,
    onVote: () => void,
    onDelete: (id: number) => void
    onSubmit: (newSession: Session) => void
}

const SessionCard = (props: Props) => {

    return (
        <Card className="card">
            <CardActionArea className="card-action-area">
                <CardContent>
                    <Typography variant="h5" component="h2" color="primary">
                        {props.session.title}
                    </Typography>
                    <Typography>
                        <small className="speaker">{" by " + props.session.speaker}</small>
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
            </CardActionArea>
            <CardActions className="card-actions">
                <Button size="small" onClick={() => props.onVote()}>
                    <ThumbUpIcon style={{ paddingRight: '6px' }} color="primary" />
                    {props.session.votes}
                </Button>
                <Button component={Link} to={"/session/" + props.session.id} >
                    <SearchIcon />
                </Button>
                <EditForm session={props.session} onSubmit={(newSession: Session) => props.onSubmit(newSession)} />
                <Button size="small" onClick={() => props.onDelete(props.session.id)}>
                    <DeleteIcon style={{ color: red[700] }} />
                </Button>
            </CardActions>
        </Card>)
}

export default SessionCard