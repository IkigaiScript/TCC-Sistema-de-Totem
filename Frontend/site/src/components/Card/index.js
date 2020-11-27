import React, { useState } from 'react'
import { PageDefault,Header,InfoWrapper, Video, Span, ImgFilme } from './style'
import { Trailer } from '../../services/TrailerApi'
import { GetPhoto } from '../../services/GetPhotoApi'

const getPhoto = new GetPhoto();
const trailer = new Trailer();

export default function Card(props){
    
    const [id] = useState(props.id)

    return(
        <PageDefault>

            <Header>

                {/* {console.log(trailer.consultTrailer(id))}
                <Video controls>
                    <source src = {trailer.consultTrailer(id)} type = 'vide/mp4'  />
                </Video>  */}
            </Header>

            <ImgFilme>

                {/* <img src = {getPhoto.getPhoto(props.image)} alt = '' height= '120' width = '100'/> */}
                <Span>{props.nome}</Span>

            </ImgFilme>

            <InfoWrapper>

                <span>Sinopse</span>
                <p style = {{'font-size': '18px'}}>{props.sinopse}</p>

            </InfoWrapper>

        </PageDefault>
    );
}