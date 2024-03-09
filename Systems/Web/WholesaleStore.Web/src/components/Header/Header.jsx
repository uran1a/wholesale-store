import { styled } from 'styled-components'

const HeaderContainer = styled.header`
    height: 75px;
    display: flex;
    padding: 0 2rem;
    justify-content: space-between;
    align-items: center;
    border-bottom: 1px solid #ccc;
    background: #3399FF;
`

export default function Header() {
    return (
        <HeaderContainer>
            <h1>Wholesale Store</h1>
        </HeaderContainer>
    )
}